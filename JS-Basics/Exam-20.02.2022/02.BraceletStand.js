function braceletStand(input) {
	const days = 5;
	let index = 0;
	const moneyPerDay = Number(input[index]);
	index++;
	const earningsPerDay = Number(input[index]);
	index++;
	const totalExpences = Number(input[index]);
	index++;
	const giftPrice = Number(input[index]);
	let profit = 0;

	profit = 5 * (moneyPerDay + earningsPerDay) - totalExpences;
	if (profit >= giftPrice) {
		console.log(
			`Profit: ${profit.toFixed(2)} BGN, the gift has been purchased.`
		);
	} else {
		console.log(`Insufficient money: ${(giftPrice - profit).toFixed(2)} BGN.`);
	}
}
braceletStand(["2.10", "17.50", "20.20", "148.50"]);
