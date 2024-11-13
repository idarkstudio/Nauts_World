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
  },
  SetRaceTime: function (time){
    try {
      window.dispatchReactUnityEvent("SetRaceTime",time)
    }catch (e){
      console.warn("Failed to dispatch CreateAcountEvent");
    }
  },
  SetLapTime: function (time){
    try {
      window.dispatchReactUnityEvent("SetLapTime",time)
    }catch (e){
      console.warn("Failed to dispatch CreateAcountEvent");
    }
  },
  GetScore: function (){
    try {
      window.dispatchReactUnityEvent("GetScore")
    }catch (e){
      console.warn("Failed to dispatch CreateAcountEvent");
    }
  },
  GetTotalScore: function (){
    try {
      window.dispatchReactUnityEvent("GetTotalScore")
    }catch (e){
      console.warn("Failed to dispatch CreateAcountEvent");
    }
  },
  GetTenRace: function (){
    try {
      window.dispatchReactUnityEvent("GetTenRace")
    }catch (e){
      console.warn("Failed to dispatch CreateAcountEvent");
    }
  },
  GetTenLap: function (){
    try {
      window.dispatchReactUnityEvent("GetTenLap")
    }catch (e){
      console.warn("Failed to dispatch CreateAcountEvent");
    }
  },
  GetUserNfts: function (){
    try {
      window.dispatchReactUnityEvent("GetUserNfts")
    }catch (e){
      console.warn("Failed to dispatch CreateAcountEvent");
    }
  },
  GetUserStakes: function (){
    try {
      window.dispatchReactUnityEvent("GetUserStakes")
    }catch (e){
      console.warn("Failed to dispatch CreateAcountEvent");
    }
  },
  ReturnToMainMenu: function (mainmenu){
    try {
      window.dispatchReactUnityEvent("ReturnToMainMenu", mainmenu)
    }catch (e){
      console.warn("Failed to dispatch CreateAcountEvent");
    }
  },
  SetBestTimes: function (jsonData) {
    try {
      window.dispatchReactUnityEvent("SetBestTimes", UTF8ToString(jsonData));
    } catch (e) {
      console.warn("Failed to dispatch event");
    }
  }
};
  
mergeInto(LibraryManager.library, WebGLFunctions)