function highJump(input) {
	let index = 0;
	let targetHeight = Number(input[index]);
	let tempGoal = targetHeight - 30;
	index++;
	let countOfJumps = 0;

	while (tempGoal <= targetHeight) {
		let isSuccess = true;
		for (let i = 0; i < 3; i++) {
			countOfJumps++;
			let reachedHeight = Number(input[index]);
			index++;

			if (reachedHeight <= tempGoal) {
				isSuccess = false;
			} else {
				tempGoal += 5;
				isSuccess = true;
				break;
			}
		}
		if (!isSuccess) {
			console.log(`Tihomir failed at ${tempGoal}sm after ${countOfJumps} jums`);
			break;
		}
	}
	countOfJumps++;
	if (tempGoal > targetHeight) {
		console.log(
			`Tihomir succeeded, he jumped over ${targetHeight}sm after ${countOfJumps} jums`
		);
	}
}
//highJump(["231", "205", "212", "213", "228", "229", "230", "235"]);
highJump(["250", "225", "224", "225", "228", "231", "235", "234", "235"]);
