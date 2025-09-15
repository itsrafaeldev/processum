// // toaster.js

// toaster.js
const toastMagic = new ToastMagic();

window.toast = {
    success: (title, message = "") => toastMagic.success(title, message),
    error: (title, message = "") => toastMagic.error(title, message),
    info: (title, message = "") => toastMagic.info(title, message),
    warning: (title, message = "") => toastMagic.warning(title, message ),
};

