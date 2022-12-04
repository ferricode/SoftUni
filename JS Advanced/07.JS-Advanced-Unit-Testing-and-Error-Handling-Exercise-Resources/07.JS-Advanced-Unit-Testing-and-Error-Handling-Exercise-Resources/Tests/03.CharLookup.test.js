let { assert } = require("chai");
let { lookupChar } = require("../03.CharLookup");

// o	If the first parameter is NOT a string or the second parameter is NOT a number - return undefined.
// o	If both parameters are of the correct type but the value of the index is incorrect (bigger than or equal to the string length or a negative number) - return "Incorrect index".
// o	If both parameters have correct types and values - return the character at the specified index in the string.

describe("Test lookupChar with incorrect type", () => {
	it("result should be undefine with incorrect first parameter", () => {
		assert.equal(lookupChar(5, 5), undefined);
	});

	it("result should be undefine with incorrect second parameter", () => {
		assert.equal(lookupChar("Pesho", "Gosho"), undefined);
	});
	it("result should be undefine with incorrect second parameter decimal", () => {
		assert.equal(lookupChar("Pesho", 5.5), undefined);
	});
	it("result should be undefine with incorrect first parameter array", () => {
		assert.equal(lookupChar([], 5), undefined);
	});
});
describe("Test lookupChar with correct type, but the value of index is incorrect", () => {
	it("result should be incorrect index with bigger index", () => {
		assert.equal(lookupChar("Todor", 7), "Incorrect index");
	});
	it("result should be incorrect index with equal index", () => {
		assert.equal(lookupChar("Todor", 5), "Incorrect index");
	});
	it("result should be incorrect index with negative index", () => {
		assert.equal(lookupChar("Todor", -7), "Incorrect index");
	});
});
describe("Test lookupChar with correct type, and correct index value", () => {
	it("result should be T with zero index (Todor)", () => {
		assert.equal(lookupChar("Todor", 0), "T");
	});
	it("result should be r with last index (Todor)", () => {
		assert.equal(lookupChar("Todor", 4), "r");
	});
});
