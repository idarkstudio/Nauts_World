var WebGLFunctions = {
  GetNFT: function () {
    try {
      window.dispatchReactUnityEvent("GetNFT");
    } catch (e) {
      console.warn("Failed to dispatch event");
    }
  },
  Login: function () {
    try {
      window.dispatchReactUnityEvent("Login");
    } catch (e) {
      console.warn("Failed to dispatch event");
    }
  },
  SetNameUser: function (json) {
    try {
      window.dispatchReactUnityEvent("SetNameUser", UTF8ToString(json) );
    } catch (e) {
      console.warn("Failed to dispatch event");
    }
  }
};
  
mergeInto(LibraryManager.library, WebGLFunctions);