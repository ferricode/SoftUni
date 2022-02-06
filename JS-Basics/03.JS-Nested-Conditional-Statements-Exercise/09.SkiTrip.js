function skiTrip(input) {
  const dayStay = Number(input[0]);
  const roomType = input[1];
  const rating = input[2];

  const rooForOnePersonPrice = 18;
  const apartmentPrice = 25;
  const presidentApartmentPrice = 35;
  let totalPrice = 0;
  //apartment, president apartment
  if (roomType === "room for one person") {
    totalPrice = (dayStay - 1) * rooForOnePersonPrice;
  } else if (roomType === "apartment") {
    totalPrice = (dayStay - 1) * apartmentPrice;
    if (dayStay < 10) {
      totalPrice *= 0.7;
    } else if (dayStay >= 10 && dayStay <= 15) {
      totalPrice *= 0.65;
    } else {
      totalPrice *= 0.5;
    }
  } else if (roomType === "president apartment") {
    totalPrice = (dayStay - 1) * presidentApartmentPrice;
    if (dayStay < 10) {
      totalPrice *= 0.9;
    } else if (dayStay >= 10 && dayStay <= 15) {
      totalPrice *= 0.85;
    } else {
      totalPrice *= 0.8;
    }
  }
  if (rating === "positive") {
    totalPrice = (totalPrice * 1.25).toFixed(2);
  } else {
    totalPrice = (totalPrice * 0.9).toFixed(2);
  }
  console.log(totalPrice);
}
skiTrip(["14","apartment","positive"]);
skiTrip(["30","president apartment","negative"]);
