function extractIncreasingSubsetFromArray(arr) {
	let res = [];
	let biggestOne = arr[0];
	res = arr.reduce((acc, currentElement) => {
		if (biggestOne <= currentElement) {
			acc.push(currentElement);
			biggestOne = currentElement;
		}
		return acc;
	}, []);

	return res;
	// let res = [];
	// let biggestOne = arr.shift();
	// res.push(biggestOne);

	// for (let el of arr) {
	// 	if (el >= biggestOne) {
	// 		res.push(el);
	// 		biggestOne = el;
	// 	}
	// }
	// return res;
}

extractIncreasingSubsetFromArray([1, 3, 8, 4, 10, 12, 3, 2, 24]);

extractIncreasingSubsetFromArray([1, 2, 3, 4]);
