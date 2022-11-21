function validityCheker(x1, y1, x2, y2) {
	let validationX1Y1zero;
	let validationX2Y2zero;
	let validationX1Y1X2Y2;

	validationX1Y1zero = Math.sqrt(x1 ** 2 + y1 ** 2);
	validationX2Y2zero = Math.sqrt(x2 ** 2 + y2 ** 2);
	validationX1Y1X2Y2 = Math.sqrt((x1 - x2) ** 2 + (y1 - y2) ** 2);

	let isValidX1Y1zero = Number.isInteger(validationX1Y1zero);
	let isValidX2Y2zero = Number.isInteger(validationX2Y2zero);
	let isValidX1Y1X2Y2 = Number.isInteger(validationX1Y1X2Y2);

	if (isValidX1Y1zero) {
		console.log(`{${x1}, ${y1}} to {0, 0} is valid`);
	} else {
		console.log(`{${x1}, ${y1}} to {0, 0} is invalid`);
	}

	if (isValidX2Y2zero) {
		console.log(`{${x2}, ${y2}} to {0, 0} is valid`);
	} else {
		console.log(`{${x2}, ${y2}} to {0, 0} is invalid`);
	}

	if (isValidX1Y1X2Y2) {
		console.log(`{${x1}, ${y1}} to {${x2}, ${y2}} is valid`);
	} else {
		console.log(`(${x1}, ${y1}} to {${x2}, ${y2}} is invalid`);
	}
}
validityCheker(2, 1, 1, 1);
console.log(`--------------------------------`);
validityCheker(3, 0, 0, 4);
