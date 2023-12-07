import React, { InputHTMLAttributes, useEffect, useState } from "react";
import ReactDOM from "react-dom";
import classNames from "classnames";

import "./AppModal.scss";

interface Props extends InputHTMLAttributes<HTMLDivElement> {
  visible: boolean;
  close: () => void;
}

export const AppModal = ({ visible, close, className, ...props }: Props) => {
  const [show, setShow] = useState(false);

  useEffect(() => {
    if (visible) {
      setShow(true);
    }
  }, [visible]);

  if (!show) {
    return null;
  }

  const wrapperClassName = classNames("modal-wrapper", {
    visible: visible,
  });

  const isWrapper = (target: EventTarget) => {
    const element = target as HTMLElement;

    return element.classList.contains("modal-wrapper");
  };

  const handleOutsideClick = (e: React.MouseEvent) => {
    if (isWrapper(e.target)) {
      close();
    }
  };

  const handleAnimationEnd = (e: React.AnimationEvent) => {
    if (!visible && isWrapper(e.target)) {
      setShow(false);
    }
  };

  return ReactDOM.createPortal(
    <div
      className={wrapperClassName}
      onMouseDown={handleOutsideClick}
      onAnimationEnd={handleAnimationEnd}
    >
      <div className={classNames("modal", className)} {...props}>
        {props.children}

        <button className="close-modal-button" onClick={close}></button>
      </div>
    </div>,
    document.body
  );
};
