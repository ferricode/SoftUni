function maxNumber(input) {
  let index = 0;
  let command = input[index];
  index++;
  let maxNumber ;
  if(command!=="Stop"){
      maxNumber = Number(command);
  }

  while (command !== "Stop") {
    let num = Number(command);

    if (maxNumber < num) {
      maxNumber = num;
    }
    command = input[index];
    index++;
  }
  console.log(maxNumber);
}
maxNumber(["-45",
"-20",
"-7",
"-99",
"Stop"]);

