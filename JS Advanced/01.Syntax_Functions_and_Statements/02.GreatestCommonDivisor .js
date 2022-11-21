function greatestCommonDivisor(num1, num2) {
	let gcd;
	if (num1 > num2) {
		for (let i = num2; i > 0; i--) {
			if (num1 % i === 0 && num2 % i === 0) {
				gcd = i;
				return gcd;
			}
		}
	} else {
		for (let i = num1; i > 0; i--) {
			if (num2 % i === 0 && num1 % i === 0) {
				gcd = i;
				return gcd;
			}
		}
	}
}

console.log(greatestCommonDivisor(12, 18));
