let { assert } = require("chai");
let { expect } = require("chai");
const mathEnforcer = require("../04.MathEnforcer");
let { addFive, subtractTen, sum } = require("../04.MathEnforcer");

//•	Test how the program behaves when passing in negative values.
//•	Test the program with floating-point numbers (use Chai’s closeTo() method to compare floating-point numbers).

describe("Test mathEnforcer functionality", () => {
	describe("Test addFive with functionality", () => {
		it("result should be undefine for string", () => {
			assert.equal(mathEnforcer.addFive("Pesho"), undefined);
		});

		it("result should be undefine for array", () => {
			assert.equal(mathEnforcer.addFive([]), undefined);
		});
		it("result should be undefine for object", () => {
			assert.equal(mathEnforcer.addFive({}), undefined);
		});
		it("result should be close to 10 for 5.99", () => {
			expect(mathEnforcer.addFive(5.999)).closeTo(
				10.999,
				0.001,
				"Numbers are close"
			);
		});
		it("result should be correct for positive number", () => {
			assert.equal(mathEnforcer.addFive(5), 10);
		});
		it("result should be correct for negative number", () => {
			assert.equal(mathEnforcer.addFive(-5), 0);
		});
	});
	describe("Test subtractTen with functionality", () => {
		it("result should be undefine for string", () => {
			assert.equal(mathEnforcer.subtractTen("Pesho"), undefined);
		});
		it("result should be undefine for array", () => {
			assert.equal(mathEnforcer.subtractTen([]), undefined);
		});
		it("result should be undefine for object", () => {
			assert.equal(mathEnforcer.subtractTen({}), undefined);
		});
		it("result should be correct for positive number", () => {
			assert.equal(mathEnforcer.subtractTen(15), 5);
		});
		it("result should be correct for negative number", () => {
			assert.equal(mathEnforcer.subtractTen(-5), -15);
		});
		it("result should be close to 10 for 20.99", () => {
			expect(mathEnforcer.subtractTen(20.999)).closeTo(
				10.999,
				0.001,
				"Numbers are close"
			);
		});
	});
	describe("Test sum with functionality", () => {
		it("result should be undefine for first argument string", () => {
			assert.equal(mathEnforcer.sum("Pesho", 5), undefined);
		});
		it("result should be undefine for second argument string", () => {
			assert.equal(mathEnforcer.sum(5, "Pesho"), undefined);
		});
		it("result should be undefine for first argument array", () => {
			assert.equal(mathEnforcer.sum([], 5), undefined);
		});
		it("result should be undefine for second argument array", () => {
			assert.equal(mathEnforcer.sum(5, []), undefined);
		});
		it("result should be undefine for first argument object", () => {
			assert.equal(mathEnforcer.sum({}, 5), undefined);
		});
		it("result should be undefine for second argument object", () => {
			assert.equal(mathEnforcer.sum(5, {}), undefined);
		});
		it("result should be correct for positive numbers", () => {
			assert.equal(mathEnforcer.sum(15, 5), 20);
		});
		it("result should be correct for negative numbers", () => {
			assert.equal(mathEnforcer.sum(-5, -10), -15);
		});
		it("result should be close to 20 for 10.99 and 10", () => {
			expect(mathEnforcer.sum(10.999, 10)).closeTo(
				20.999,
				0.001,
				"Numbers are close"
			);
		});
		it("result should be close to 20 for 10 and 10.999", () => {
			expect(mathEnforcer.sum(10, 10.999)).closeTo(
				20.999,
				0.001,
				"Numbers are close"
			);
		});
	});
});
