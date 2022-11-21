function timeToWalk(steps, footPrint, speed) {
	let distanceInMeters = steps * footPrint;
	let speedMetersInSec = speed / 3.6;
	let time = distanceInMeters / speedMetersInSec;
	let res = Math.floor(distanceInMeters / 500);

	let timeInMin = Math.floor(time / 60);
	let timeInSec = Number(time - timeInMin * 60).toFixed(0);
	let timeInHours = Math.floor(time / 3600);
	timeInMin += res;
	timeInHours += Math.floor(timeInMin / 60);
	timeInMin = timeInMin % 60;

	let formattedHours = timeInHours < 10 ? `0${timeInHours}` : `${timeInHours}`;
	let formattedMins = timeInMin < 10 ? `0${timeInMin}` : `${timeInMin}`;
	let formattedSec = timeInSec < 10 ? `0${timeInSec}` : `${timeInSec}`;
	console.log(`${formattedHours}:${formattedMins}:${formattedSec}`);
}
timeToWalk(4000, 0.6, 5);
timeToWalk(2564, 0.7, 5.5);
