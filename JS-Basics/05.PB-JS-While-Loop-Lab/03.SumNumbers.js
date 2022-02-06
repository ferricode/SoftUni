function sumNumbers(input) {
  let index = 0;
  let targetSum = Number(input[index]);
  index++;
  let totalSum = Number(input[index]);
  index++;
  
  while (totalSum < targetSum) {
    totalSum += Number(input[index]);
    index++;
  }
  console.log(totalSum);
}
sumNumbers(["20", "1", "2", "3", "4", "5", "6"]);
