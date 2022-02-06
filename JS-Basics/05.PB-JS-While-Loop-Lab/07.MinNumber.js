function minNumber(input) {
  let index = 0;
  let command = input[index];
  index++;
  let minNumber;
  if (command !== "Stop") {
    minNumber = Number(command);
  }

  while (command !== "Stop") {
    let num = Number(command);

    if (minNumber > num) {
      minNumber = num;
    }
    command = input[index];
    index++;
  }
  console.log(minNumber);
}
minNumber(["-10", "20", "-30", "Stop"]);
