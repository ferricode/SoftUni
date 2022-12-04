let bookSelection = require("../03.Book-selection/solution");
let { assert } = require("chai");

describe("Tests bookSelection", function () {
	describe("Test isGenreSuitable", function () {
		function concatenateStr(genre, age) {
			return `Books with ${genre} genre are not suitable for kids at ${age} age`;
		}
		it("not suitable genre for kids", function () {
			let expectText = concatenateStr("Horror", 12);
			assert.equal(bookSelection.isGenreSuitable("Horror", 12), expectText);
			expectText = concatenateStr("Thriller", 12);
			assert.equal(bookSelection.isGenreSuitable("Thriller", 12), expectText);
		});
		it("Suitable genre for kids and for adults", function () {
			let expText = `Those books are suitable`;
			assert.equal(bookSelection.isGenreSuitable("Comedy", 10), expText);
			assert.equal(bookSelection.isGenreSuitable("Thriller", 15), expText);
		});
	});
	describe("Test isItAffordable", function () {
		it("invalid input", function () {
			assert.throw(
				() => bookSelection.isItAffordable("pesho", "gosho"),
				"Invalid input"
			);
			assert.throw(
				() => bookSelection.isItAffordable("pesho", 10),
				"Invalid input"
			);
			assert.throw(
				() => bookSelection.isItAffordable(10, "gosho"),
				"Invalid input"
			);
			assert.throw(
				() => bookSelection.isItAffordable(10, "10"),
				"Invalid input"
			);
			assert.throw(() =>
				bookSelection.isItAffordable(10, "10", "Invalid input")
			);
		});
		it("not enough money", function () {
			assert.equal(
				bookSelection.isItAffordable(50, 20),
				"You don't have enough money"
			);
			assert.equal(
				bookSelection.isItAffordable(30, 10),
				"You don't have enough money"
			);
		});
		it("book bought", function () {
			let price = 10;
			let budget = 25;
			let result = budget - price;
			assert.equal(
				bookSelection.isItAffordable(price, budget),
				`Book bought. You have ${result}$ left`
			);
		});
	});
	describe("Test suitableTitles", function () {
		it("invalid input", () => {
			assert.throw(() => bookSelection.suitableTitles(10, 10), "Invalid input");
			assert.throw(
				() => bookSelection.suitableTitles("array", "string"),
				"Invalid input"
			);
			assert.throw(
				() => bookSelection.suitableTitles(10, "string"),
				"Invalid input"
			);
			assert.throw(
				() => bookSelection.suitableTitles("array", 10),
				"Invalid input"
			);
			assert.throw(() => bookSelection.suitableTitles({}, 10), "Invalid input");
			assert.throw(() => bookSelection.suitableTitles(10, {}), "Invalid input");
			assert.throw(
				() =>
					bookSelection.suitableTitles(
						[{ title: "The Da Vinci Code", genre: "Thriller" }],
						10
					),
				"Invalid input"
			);
			assert.throw(
				() =>
					bookSelection.suitableTitles(
						[{ title: "The Da Vinci Code", genre: "Thriller" }],
						[]
					),
				"Invalid input"
			);
			assert.throw(
				() =>
					bookSelection.suitableTitles(
						[{ title: "The Da Vinci Code", genre: "Thriller" }],
						{}
					),
				"Invalid input"
			);
		});
		it("Correct data", () => {
			let input = [
				{ title: "The Da Vinci Code", genre: "Thriller" },
				{ title: "Nobody", genre: "Thriller" },
				{ title: "The Da Vinci Code", genre: "Drama" },
				{ title: "The Black phone", genre: "Horror" },
			];
			let result = ["The Da Vinci Code", "Nobody"];
			assert.equal(
				bookSelection.suitableTitles(input, "Thriller").join(" "),
				result.join(" ")
			);
			result = ["The Black phone"];
			assert.equal(
				bookSelection.suitableTitles(input, "Horror").join(" "),
				result.join(" ")
			);
			result = [];
			assert.equal(
				bookSelection.suitableTitles(input, "Comedy").join(" "),
				result.join(" ")
			);
		});
	});
});
