function roadRadar(speed, area) {
	let result = "";
	let status = "";

	function difference(speed, limit) {
		if (speed <= limit) {
			return 0;
		} else {
			return speed - limit;
		}
	}
	function areaLimit(area) {
		let limit;
		switch (area) {
			case "motorway":
				limit = 130;
				break;
			case "interstate":
				limit = 90;
				break;
			case "city":
				limit = 50;
				break;
			case "residential":
				limit = 20;
				break;
		}
		return limit;
	}

	let areaLimitSpeed = areaLimit(area);
	let differenceKm = difference(speed, areaLimitSpeed);

	if (differenceKm === 0) {
		result = `Driving ${speed} km/h in a ${areaLimit(area)} zone`;
	}
	if (0 < differenceKm && differenceKm <= 20) {
		status = "speeding";
	} else if (differenceKm <= 40) {
		status = "excessive speeding";
	} else {
		status = "reckless driving";
	}
	if (result === "") {
		result = `The speed is ${differenceKm} km/h faster than the allowed speed of ${areaLimitSpeed} - ${status}`;
	}

	return result;
}

console.log(roadRadar(200, "motorway"));
