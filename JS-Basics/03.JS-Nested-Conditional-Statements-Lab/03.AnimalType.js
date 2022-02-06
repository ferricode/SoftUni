//1.	dog -> mammal
//2.	crocodile, tortoise, snake -> reptile
//3.	others -> unknown

function animalType(input) {
  const type = input[0];

  switch (type) {
    case "dog":
      console.log("mammal");
    case "crocodile":
    case "tortoise":
    case "snake":
      console.log("reptile");
      break;
    default:
      console.log("unknown");
      break;
  }
}
animalType(["snake"]);
