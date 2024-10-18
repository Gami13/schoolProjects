// ==UserScript==
// @name         Car Info Scraper with Button
// @namespace    http://tampermonkey.net/
// @version      1.1
// @description  Scrape car details like make, model, year, and tire data from a webpage when a button is clicked.
// @author       You
// @match        https://www.wheel-size.com/*
// @grant        none
// ==/UserScript==

(() => {
	function scrape() {
		const car = {
			make: "",
			model: "",
			year: "",
			fuelTypes: [],
		};
		const title = document.querySelector(
			"#title-header > span.fw-500",
		).textContent;
		console.log(title);
		const year = title.split(" ")[0];
		const make = title.split(" ")[1];
		let model = title.split(" ")[2];
		if (title.split(" ")[3]) {
			model += ` ${title.split(" ")[3]}`;
		}
		if (title.split(" ")[4]) {
			model += ` ${title.split(" ")[4]}`;
		}

		car.make = make;
		car.model = model;
		car.year = year;

		for (const x of document.querySelectorAll(".region-trim")) {
			const fuelType = {
				type: "",
				tires: [],
			};
			fuelType.type = x.querySelector(".panel-hdr-trim-name").textContent;
			x.querySelector("table")
				.querySelectorAll("tr")
				.forEach((y, index) => {
					if (index === 0) return;
					try {
						let tire;

						if (
							y.querySelectorAll("td")[0].querySelectorAll("span")[1]
								.textContent === "OE"
						) {
							tire = y
								.querySelectorAll("td")[0]
								.querySelectorAll("span")[4].textContent;
						} else {
							tire = y
								.querySelectorAll("td")[0]
								.querySelectorAll("span")[2].textContent;
						}
						const tireArr = tire.split("/");
						if (tireArr === undefined) return;
						console.log(tireArr);
						const width = tireArr[0];

						let thickness = tireArr[1].split("R")[0];

						thickness = thickness.replace(/[a-zA-Z]/g, "");
						const radius = tireArr[1].split("R")[1];
						const rim = y
							.querySelectorAll("td")[1]
							.querySelectorAll("span")[1].textContent;
						let offsetStart = "";
						let offsetEnd = "";
						if (y.querySelectorAll("td")[2].querySelectorAll("span")[0]) {
							const offset = y
								.querySelectorAll("td")[2]
								.querySelectorAll("span")[0].textContent;
							offsetStart = offset
								.match(/-?\d+(\.\d+)?\s*-\s*-?\d+(\.\d+)?/)[0]
								.split(" - ")[0];
							offsetEnd = offset
								.match(/-?\d+(\.\d+)?\s*-\s*-?\d+(\.\d+)?/)[0]
								.split(" - ")[1];
						}

						let bar = "";
						if (y.querySelectorAll("td")[5].querySelectorAll("span")[1]) {
							bar = y
								.querySelectorAll("td")[5]
								.querySelectorAll("span")[1].textContent;
						}
						const tireData = {
							radius: radius,
							width: width,
							thickness: thickness,
							rim: rim,
							offsetStart: offsetStart,
							offsetEnd: offsetEnd,
							bar: bar,
						};
						fuelType.tires.push(tireData);
					} catch {}
				});
			car.fuelTypes.push(fuelType);
		}
		navigator.clipboard.writeText(JSON.stringify(car));
		return car;
	}

	function addButton() {
		// Create a button element
		const button = document.createElement("button");
		button.textContent = "Scrape Car Info";
		button.style.position = "fixed";
		button.style.bottom = "20px";
		button.style.right = "20px";
		button.style.padding = "10px 20px";
		button.style.backgroundColor = "#007BFF";
		button.style.color = "#FFF";
		button.style.border = "none";
		button.style.borderRadius = "5px";
		button.style.cursor = "pointer";
		button.style.zIndex = "9999";

		// Add a click event to the button to run the scrape function
		button.addEventListener("click", scrape);

		// Append the button to the body of the page
		document.body.appendChild(button);
	}

	// Run the addButton function when the page is fully loaded
	window.addEventListener("load", addButton);
})();
