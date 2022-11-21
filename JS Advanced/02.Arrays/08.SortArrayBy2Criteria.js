function sortArrayBy2Criteria(arr) {
	//Variant 1
	// let sortArr = arr.sort((a, b) => {
	// 	if (a.length !== b.length) {
	// 		return a.length - b.length;
	// 	} else {
	// 		return a.localeCompare(b);
	// 	}
	// });
	// console.log(sortArr.join("\n"));

	//Vartiant 2.
	// arr
	// 	.sort((a, b) => {
	// 		a.length !== b.length ? a.length - b.length : a.localeCompare(b);
	// 	})
	// 	.join("\n");

	//Variant 3
	return arr
		.sort((a, b) => {
			return a.length - b.length || a.localeCompare(b);
		})
		.join("\n");
}

console.log(sortArrayBy2Criteria(["alpha", "beta", "gamma"]));
sortArrayBy2Criteria(["Isacc", "Theodor", "Jack", "Harrison", "George"]);
