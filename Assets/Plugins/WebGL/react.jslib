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
  SetUserName: function (json) {
    try {
      window.dispatchReactUnityEvent("SetNameUser", UTF8ToString(json) );
    } catch (e) {
      console.warn("Failed to dispatch event");
    }
  },
  CreateAcount: function (){
    try {
      window.dispatchReactUnityEvent("CreateAcount")
    }catch (e){
      console.warn("Failed to dispatch CreateAcountEvent");
    }
  }
};
  
mergeInto(LibraryManager.library, WebGLFunctions);