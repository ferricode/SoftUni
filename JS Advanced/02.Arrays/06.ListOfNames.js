function listOfNames(arrOfName) {
	// let res = arrOfName.sort((a, b) => a.localeCompare(b));

	// for (let i = 0; i < res.length; i++) {
	// 	console.log(`${i + 1}.${res[i]}`);
	// }
	//});

	arrOfName
		.sort((a, b) => a.localeCompare(b))
		.forEach((x, i) => console.log(`${i + 1}.${x}`));
}

listOfNames(["John", "Bob", "Christina", "Ema", "Anna"]);
