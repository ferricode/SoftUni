function moving(input) {
  const width = Number(input[0]);
  const length = Number(input[1]);
  const heigth = Number(input[2]);
  let volume = width * length * heigth;
  let index = 3;
  let command = input[index];
  let boxes = 0;

  while (command !== "Done") {
    boxes = command;
    if (volume - boxes > 0) {
      volume -= boxes;
      index++;
      command = input[index];
    } else {
      break;
    }
  }
  if (command === "Done" && volume > 0) {
    console.log(`${volume} Cubic meters left.`);
  } else {
    console.log(
      `No more free space! You need ${boxes - volume} Cubic meters more.`
    );
  }
}
moving(["10", "1", "2", "4", "6", "Done"]);
