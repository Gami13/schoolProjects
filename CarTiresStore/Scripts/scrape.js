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
					//'195/65R15'
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
					//split on any letters instead of R
					// const thickness = tireArr[1].split(/[a-zA-Z]/)[0];
					// const radius = tireArr[1].split(/[0-9]/)[1];
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

scrape();
