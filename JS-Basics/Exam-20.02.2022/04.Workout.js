function workout(input) {
	let index = 0;
	let days = Number(input[index]);
	index++;
	let kilometersPerDay = Number(input[index]);
	let totalKilometers = kilometersPerDay;
	index++;
	for (let i = 1; i <= days; i++) {
		let koef = Number(input[index]) / 100;
		kilometersPerDay = kilometersPerDay + kilometersPerDay * koef;
		totalKilometers += kilometersPerDay;
		index++;
	}
	let diff = Math.abs(1000 - totalKilometers);
	if (totalKilometers >= 1000) {
		console.log(
			`You've done a great job running ${Math.ceil(diff)} more kilometers!`
		);
	} else {
		console.log(
			`Sorry Mrs. Ivanova, you need to run ${Math.ceil(diff)} more kilometers`
		);
	}
}
workout(["4", "100", "30", "50", "60", "80"]);
