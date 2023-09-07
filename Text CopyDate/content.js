document.addEventListener("copy", function (event) {
  const copiedText = window.getSelection().toString();
  const copiedDate = new Date().toLocaleString();
  const copiedWebsite = window.location.href;

  const data = {
    text: copiedText,
    website: copiedWebsite,
    date: copiedDate,
  };

  chrome.storage.sync.get("copiedData", function (result) {
    const copiedData = result.copiedData || [];
    copiedData.unshift(data);
    chrome.storage.sync.set({ copiedData: copiedData }, function () {
      console.log("Copied data saved.");
    });
  });
});
