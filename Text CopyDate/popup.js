document.addEventListener("DOMContentLoaded", function () {
    chrome.storage.sync.get("copiedData", function (data) {
      const copiedData = data.copiedData || [];
      const tableBody = document.getElementById("copiedData");
  
      for (const item of copiedData) {
        const row = document.createElement("tr");
        const textCell = document.createElement("td");
        const websiteCell = document.createElement("td");
        const dateCell = document.createElement("td");
  
        textCell.textContent = item.text || "N/A";
        websiteCell.textContent = item.website || "N/A";
        dateCell.textContent = item.date || "N/A";
  
        row.appendChild(textCell);
        row.appendChild(websiteCell);
        row.appendChild(dateCell);
  
        tableBody.appendChild(row);
      }
    });
  });
  