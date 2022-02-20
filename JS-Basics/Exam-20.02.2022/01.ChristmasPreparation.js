function christmasPrep(input) {
	const papperPrice = 5.8;
	const textilePrice = 7.2;
	const gluePrice = 1.2;

	let totalPrice = 0;
	let index = 0;
	let papperCount = Number(input[index]);
	index++;
	let textileCount = Number(input[index]);
	index++;
	let glueCount = Number(input[index]);
	index++;
	let discount = Number(input[index]);

	totalPrice =
		papperPrice * papperCount +
		textilePrice * textileCount +
		gluePrice * glueCount;
	totalPrice = totalPrice - (totalPrice * discount) / 100;
	console.log(totalPrice.toFixed(3));
}
christmasPrep(["4", "2", "5", "13"]);
