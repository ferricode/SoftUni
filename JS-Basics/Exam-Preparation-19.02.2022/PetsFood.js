function petsFood(input) {
	let index = 0;
	let days = Number(input[index]);
	index++;
	let totalFood = Number(input[index]);
	let biscuits = 0;
	let dogsFood = 0;
	let catsFood = 0;

	while (days !== 0) {
		let totalfood = 0;
		for (let i = 0; i < 3; i++) {
			index++;
			let dogsDayFood = Number(input[index]);
			dogsFood += dogsDayFood;
			index++;
			let catsDayFood = Number(input[index]);
			catsFood += catsDayFood;
			if (days % 3 === 0) {
				totalFood = dogsDayFood + catsDayFood;
			}
			days--;
		}
	}
}
