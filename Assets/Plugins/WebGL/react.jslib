var WebGLFunctions = {
  GetNFT: function () {
      try {
        window.dispatchReactUnityEvent("GetNFT");
      } catch (e) {
        console.warn("Failed to dispatch event");
      }
    },
  Login: function (userName) {
    try {
      window.dispatchReactUnityEvent("Login", UTF8ToString(userName) );
    } catch (e) {
      console.warn("Failed to dispatch event");
    }
  },
};

mergeInto(LibraryManager.library, WebGLFunctions);