function wordsUpperCase(text) {
	return text.match(/\w+/g).join(", ").toUpperCase();

	// let res = [];
	// let buff = "";

	// for (let i = 0; i < text.length; i++) {
	// 	let chCode = text.charCodeAt(i);
	// 	if ((chCode >= 65 && chCode <= 90) || (chCode >= 97 && chCode <= 172)) {
	// 		buff += text[i];
	// 	} else {
	// 		res.push(buff);
	// 		buff = "";
	// 	}
	// }
	// if (buff) {
	// 	res.push(buff);
	// }
	// console.log(res);
}
console.log(wordsUpperCase("Hi, how are you?"));
console.log(`------------------------------`);
wordsUpperCase(`hello`);
