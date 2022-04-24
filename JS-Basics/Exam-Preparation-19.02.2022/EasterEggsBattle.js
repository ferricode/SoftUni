function easterEggsBattle(input) {
	let index = 0;
	let firstPlayersEggs = Number(input[index]);
	index++;
	let secondPlayersEggs = Number(input[index]);
	index++;
	let command = input[index];
	index++;

	while (command !== "End of battle") {
		if (command === "one") {
			secondPlayersEggs--;
		} else {
			firstPlayersEggs--;
		}
		if (firstPlayersEggs === 0) {
			console.log(
				`Player one is out of eggs. Player two has ${secondPlayersEggs} eggs left.`
			);
			break;
		}
		if (secondPlayersEggs === 0) {
			console.log(
				`Player two is out of eggs. Player one has ${secondPlayersEggs} eggs left.`
			);
			break;
		}
		command = input[index];
		index++;
	}

	console.log(`Player one has ${firstPlayersEggs} eggs left.`);
	console.log(`Player two has ${secondPlayersEggs} eggs left.`);
}
easterEggsBattle([5, 4, "one", "two", "one", "two", "two", "End of battle"]);
