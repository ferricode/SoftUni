import { calculator } from '../utils/calculator';

describe('Calculator', () => {
    ;
    test('Add two positive numbers', () => {
        //Arrange
        let firtstNumber = 5;
        let secondNumber = 7;
        let expectedResult = 12;

        //Act
        const actualResult = calculator.sum(firtstNumber, secondNumber);

        //Assert
        expect(actualResult).toBe(expectedResult);
    });

    test('Add undefined to a positive number', () => {
        expect(calculator.sum(2)).toBe(NaN);
    });
});