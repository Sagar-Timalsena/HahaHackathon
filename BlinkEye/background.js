chrome.alarms.create({ periodInMinutes: 1 });

chrome.alarms.onAlarm.addListener((alarm) => {
  if (alarm.name === 'blinkReminder') {
    // Notify the user to blink their eyes.
    chrome.action.setBadgeText({ text: 'Blink!' });
  }
});
