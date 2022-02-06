function onTimeForTheExam(input) {
  const examHour = Number(input[0]);
  const examMinutes = Number(input[1]);
  const arrivelHour = Number(input[2]);
  const arrivelMin = Number(input[3]);

  const totalExamMin = examHour * 60 + examMinutes;
  const totalArrivelMin = arrivelHour * 60 + arrivelMin;
  const differenceInTime = Math.abs(totalExamMin - totalArrivelMin);
  const hourDiff = Math.floor(differenceInTime / 60);

  let minDiff = differenceInTime % 60;

  if (minDiff === 0 || (minDiff < 10 && hourDiff > 0)) {
    minDiff = `0${minDiff}`;
  }

  if (totalArrivelMin === totalExamMin) {
    console.log("On time");
  } else if (totalArrivelMin > totalExamMin && differenceInTime < 60) {
    console.log("Late");
    console.log(`${minDiff} minutes after the start`);
  } else if (totalArrivelMin > totalExamMin && differenceInTime >= 60) {
    console.log("Late");
    console.log(`${hourDiff}:${minDiff} hours after the start`);
  } else if (differenceInTime <= 30) {
    console.log("On time");
    console.log(`${minDiff} minutes before the start`);
  } else if (differenceInTime > 30 && differenceInTime < 60) {
    console.log("Early");
    console.log(`${minDiff} minutes before the start`);
  } else {
    console.log("Early");
    console.log(`${hourDiff}:${minDiff} hours before the start`);
  }
}
//onTimeForTheExam(["14","00","13","55"]);
onTimeForTheExam(["16","00","15","00"]);
