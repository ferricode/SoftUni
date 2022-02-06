function graduation(input) {
  let index = 0;

  let name = input[index];
  index++;
  let counter = 0;
  let i = 1;
  
  let sumGrade = 0;
  let isExcluded=false;

  while (i <= 12) {
    let grade = Number(input[index]);
    index++;

    if (grade < 4.0) {
      counter++;
      if (counter > 1) {
          console.log(`${name} has been excluded at ${i} grade`)
          isExcluded=true;
        break;
      }
      continue;
    }
    sumGrade+=grade;
    i++;
  }
 if(!isExcluded){
    let avgGrade=(sumGrade/12).toFixed(2);
    console.log(`${name} graduated. Average grade: ${avgGrade}`)
 }
}
graduation(["Mimi", 
"5",
"6",
"5",
"6",
"5",
"6",
"6",
"2",
"3"])

