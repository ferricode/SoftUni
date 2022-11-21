function printEveryNthElement(array, step) {
	// let res = [];
	// for (let i = 0; i < array.length; i += step) {
	// 	res.push(array[i]);
	// }
	// return res;
	return array.filter((el, i) => {
		if (i % step === 0) {
			return el;
		}
	});
}
printEveryNthElement(["5", "20", "31", "4", "20"], 2);
console.log(`-------------------------------`);
printEveryNthElement(["dsa", "asd", "test", "tset"], 2);
console.log(`-------------------------------`);
printEveryNthElement(["1", "2", "3", "4", "5"], 6);
