function summerOutfit(input) {
  const temperature = Number(input[0]);
  const dayTime = input[1];

  let outfit;
  let shoes;

  if (10 <= temperature && temperature<= 18) {
    switch (dayTime) {
      case "Morning":outfit = "Sweatshirt";shoes = "Sneakers";break;
      case "Afternoon":outfit = "Shirt";shoes = "Moccasins";break;
      case "Evening":outfit = "Shirt"; shoes = "Moccasins";break;
    }
  } else if (18 < temperature && temperature <= 24) {
      switch (dayTime) {
        case "Morning":outfit = "Shirt";shoes = "Moccasins";break;
        case "Afternoon":outfit = "T-Shirt";shoes = "Sandals"; break;
        case "Evening":outfit = "Shirt";shoes = "Moccasins";break;
      }
    }else if (temperature >= 25) {
      switch (dayTime) {
        case "Morning": outfit = "Shirt";shoes = "Sandals";break;
        case "Afternoon":outfit = "Swim Suit";shoes = "Barefoot";break;
        case "Evening": outfit = "Shirt";shoes = "Moccasins"; break;
      }
    }
    console.log(`It's ${temperature} degrees, get your ${outfit} and ${shoes}.`)
}
 
summerOutfit(["28","Evening"]);
