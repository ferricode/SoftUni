function excursionSale(input) {
	index = 0;
	let seaPackage = Number(input[index]);
	index++;
	let mountainPackage = Number(input[index]);
	index++;
	let profit = 0;
	let isSoldOut = false;

	let command = input[index];

	while (command !== "Stop") {
		if (seaPackage === 0 && mountainPackage === 0) {
			isSoldOut = true;
			break;
		}
		// if (command === "sea" && seaPackage === 0 && mountainPackage != 0) {
		// 	index++;
		// command = input[index];
		//     continue;
		// } else
		if (command === "sea" && seaPackage != 0) {
			profit += 680;
			seaPackage--;
		}
		// if (command === "mountain" && mountainPackage === 0 && seaPackage != 0) {

		//     continue;
		// } else
		if (command === "mountain" && mountainPackage != 0) {
			profit += 499;
			mountainPackage--;
		}
		index++;
		command = input[index];
	}
	if (isSoldOut) {
		console.log(`Good job! Everything is sold.`);
	}
	console.log(`Profit: ${profit} leva.`);
}
excursionSale([
	"6",
	"3",
	"sea",
	"mountain",
	"mountain",
	"mountain",
	"sea",
	"Stop",
]);
