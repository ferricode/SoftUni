function examPreparation(input) {
  let countOfBadGrades = input[0];
  let index = 1;
  let command = input[index];
  let problemsCount = 0;
  let sumGrades = 0;
  let numOfBadGrades = 0;

  while (command !== "Enough") {
    problemsCount++;
    index++;
    let currentGrade = Number(input[index]);
    sumGrades += currentGrade;

    if (currentGrade <= 4) {
      numOfBadGrades++;
    }

    if (numOfBadGrades >= countOfBadGrades) {
      console.log(`You need a break, ${numOfBadGrades} poor grades.`);
      break;
    }
    index++;
    command = input[index];
  }
  if (command === "Enough") {
    let avgGrade = (sumGrades / problemsCount).toFixed(2);
    console.log(`Average score: ${avgGrade}`);
    console.log(`Number of problems: ${problemsCount}`);
    index -= 2;
    let command = input[index];
    console.log(`Last problem: ${command}`);
  }
}
examPreparation(["2", "Income", "3", "Game Info", "6", "Best Player", "4"]);
