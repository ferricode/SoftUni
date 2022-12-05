let companyAdministration = require("../03.Company-administration/companyAdministration");
let { assert } = require("chai");

describe("Tests companyAdministration", function () {
	describe("Tests hiringEmployee", () => {
		it("wrong position", () => {
			let expectText = `We are not looking for workers for this position.`;
			assert.throw(
				() => companyAdministration.hiringEmployee("Peter", "Accountant", 4),
				expectText
			);
			assert.throw(
				() => companyAdministration.hiringEmployee("Lola", "Teacher", 21),
				expectText
			);
		});
		it("Right position - Programmer, but not enough experience", () => {
			let name = "Lola";
			let expectText = `${name} is not approved for this position.`;
			assert.equal(
				companyAdministration.hiringEmployee(name, "Programmer", 2),
				expectText
			);
			assert.equal(
				companyAdministration.hiringEmployee(name, "Programmer", 0),
				expectText
			);
		});
		it("Right position - Programmer, enough experience >=3", () => {
			let name = "Lola";
			let expectText = `Lola was successfully hired for the position Programmer.`;
			assert.equal(
				companyAdministration.hiringEmployee(name, "Programmer", 3),
				expectText
			);
			assert.equal(
				companyAdministration.hiringEmployee(name, "Programmer", 16),
				expectText
			);
		});
	});
	describe("Tests calculateSalary", () => {
		it("wrong input - not a number or less then zero", () => {
			let expText = "Invalid hours";
			assert.throw(
				() => companyAdministration.calculateSalary("not a number"),
				expText
			);
			assert.throw(() => companyAdministration.calculateSalary({}), expText);
			assert.throw(
				() => companyAdministration.calculateSalary([3, "Lola", "67"]),
				expText
			);
			assert.throw(() => companyAdministration.calculateSalary(-10), expText);
		});
		it("Right input less then 160", () => {
			assert.equal(companyAdministration.calculateSalary(100), 100 * 15);
			assert.equal(companyAdministration.calculateSalary(54), 54 * 15);
		});
		it("Right input more then 160", () => {
			assert.equal(companyAdministration.calculateSalary(171), 171 * 15 + 1000);
			assert.equal(companyAdministration.calculateSalary(161), 161 * 15 + 1000);
		});
	});
	describe("Tests firedEmployee", () => {
		it("invalid input", () => {
			let expText = "Invalid input";
			assert.throw(
				() => companyAdministration.firedEmployee(["Peter", "Ivan"], "string"),
				expText
			);
			assert.throw(
				() => companyAdministration.firedEmployee(["Peter", "Ivan"], {}),
				expText
			);
			assert.throw(
				() =>
					companyAdministration.firedEmployee(
						["Peter", "Ivan"],
						["Koko", "Dungeon"]
					),
				expText
			);
			assert.throw(
				() => companyAdministration.firedEmployee(["Peter", "Ivan"], 5),
				expText
			);
			assert.throw(
				() => companyAdministration.firedEmployee(["Peter", "Ivan"], -1),
				expText
			);
			assert.throw(() => companyAdministration.firedEmployee({}, 10), expText);
			assert.throw(() => companyAdministration.firedEmployee(19, 10), expText);
		});
		it("correct input", () => {
			assert.equal(
				companyAdministration.firedEmployee(["Peter", "Ivan"], 1),
				"Peter"
			);
			assert.equal(
				companyAdministration.firedEmployee(["Peter", "Ivan"], 0),
				"Ivan"
			);
			assert.equal(
				companyAdministration.firedEmployee(["Peter", "Ivan", "George"], 2),
				"Peter, Ivan"
			);
		});
	});
});
