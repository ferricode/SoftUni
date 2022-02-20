function excursionCalculator(input) {
	const countOfPeople = Number(input[0]);
	const season = input[1];

	let finalMoney = 0;

	if (countOfPeople <= 5) {
		if (season === "spring") {
			finalMoney = countOfPeople * 50;
		} else if (season === "summer") {
			finalMoney = countOfPeople * 48.5 * (1 - 0.15);
		} else if (season === "autumn") {
			finalMoney = countOfPeople * 60;
		} else if (season === "winter") {
			finalMoney = countOfPeople * 86 * (1 + 0.08);
		}
	} else if (season === "spring") {
		finalMoney = countOfPeople * 48;
	} else if (season === "summer") {
		finalMoney = countOfPeople * 45 * (1 - 0.15);
	} else if (season === "autumn") {
		finalMoney = countOfPeople * 49.5;
	} else if (season === "winter") {
		finalMoney = countOfPeople * 85 * (1 + 0.08);
	}
	console.log(`${finalMoney.toFixed(2)} leva.`);
}
excursionCalculator(["20", "winter"]);
