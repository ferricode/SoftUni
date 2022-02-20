function substitue(input) {
	let index = 0;
	const startK = Number(input[index]);
	const endK = 8;
	index++;
	const endL = Number(input[index]);
	const startL = 9;
	index++;
	const startM = Number(input[index]);
	const endM = 8;
	index++;
	const endN = Number(input[index]);
	const startN = 9;
	let counter = 0;
	let isDone = false;

	for (let k = startK; k <= endK; k++) {
		for (let l = startL; l >= endL; l--) {
			for (let m = startM; m <= endM; m++) {
				for (let n = startN; n >= endN; n--) {
					if (k % 2 === 0 && m % 2 === 0 && l % 2 != 0 && n % 2 != 0) {
						if (k == m && l == n) {
							if (counter < 6) {
								console.log(`Cannot change the same player.`);
							}
						} else if (counter < 6) {
							console.log(`${k}${l} - ${m}${n}`);
							counter++;
						} else {
							isDone = true;
							break;
						}
					}
					if (isDone) {
						break;
					}
				}
			}
		}
	}
}
substitue(["6", "7", "5", "6"]);
