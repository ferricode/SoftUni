function sum(num) {
	let sum = num;

	function calc(num2) {
		sum += num2;
		return calc;
	}
	calc.toString = function () {
		return sum;
	};
	return calc;
}

console.log(sum(1)(7).toString());
