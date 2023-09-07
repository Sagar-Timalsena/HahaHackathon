chrome.runtime.onMessage.addListener((message, sender, sendResponse) => {
  if (message.request === "getCopiedText") {
    chrome.scripting.executeScript({
      target: { tabId: sender.tab.id },
      function: () => {
        const text = document.getSelection().toString();
        chrome.runtime.sendMessage({ copiedText: text });
      },
    });
  }
});
