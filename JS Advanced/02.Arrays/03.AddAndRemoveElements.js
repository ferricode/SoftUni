function addAndRemoveElements(arrOfCommands) {
	let res = [];
	let num = 1;

	arrOfCommands.forEach((command) => {
		command === "add" ? res.push(num) : res.pop(num);
		num++;
	});
	return res.length === 0 ? "Empty" : res.join("\n");
	//Variation 2
	// let res = [];
	// let num = 1;
	// for (let command of arrOfCommands) {
	// 	switch (command) {
	// 		case "add":
	// 			res.push(num);
	// 			num++;
	// 			break;
	// 		case "remove":
	// 			res.pop();
	// 			num++;
	// 			break;
	// 	}
	// }
	// if (res.length === 0) {
	// 	console.log("Empty");
	// } else {
	// 	console.log(res.join("\n"));
	// }
}

addAndRemoveElements(["add", "add", "add", "add"]);
addAndRemoveElements(["add", "add", "remove", "add", "add"]);
addAndRemoveElements(["remove", "remove", "remove"]);
