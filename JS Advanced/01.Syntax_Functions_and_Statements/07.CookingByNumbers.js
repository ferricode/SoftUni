function cookingByNumbers(inputNumber, cmd1, cmd2, cmd3, cmd4, cmd5) {
	/*
    •	chop - divide the number by two
    •	dice - square root of a number
    •	spice - add 1 to the number
    •	bake - multiply number by 3
    •	fillet - subtract 20% from the number

        */
	inputNumber = manipulator(inputNumber, cmd1);
	inputNumber = manipulator(inputNumber, cmd2);
	inputNumber = manipulator(inputNumber, cmd3);
	inputNumber = manipulator(inputNumber, cmd4);
	inputNumber = manipulator(inputNumber, cmd5);
	function manipulator(num, command) {
		switch (command) {
			case "chop":
				num /= 2;
				console.log(num);
				break;
			case "dice":
				num = Math.sqrt(num);
				console.log(num);
				break;
			case "spice":
				num += 1;
				console.log(num);
				break;
			case "bake":
				num *= 3;
				console.log(num);
				break;
			case "fillet":
				num *= 0.8;
				console.log(num);
				break;
		}
		return num;
	}
}
cookingByNumbers("32", "chop", "chop", "chop", "chop", "chop");
cookingByNumbers("9", "dice", "spice", "chop", "bake", "fillet");
