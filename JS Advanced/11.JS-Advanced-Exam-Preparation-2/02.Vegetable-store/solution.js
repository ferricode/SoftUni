class VegetableStore {
	constructor(owner, location) {
		this.owner = owner;
		this.location = location;
		this.availableProducts = [];
		this.addedProducts = [];
	}
	loadingVegetables(vegetables) {
		//["Okra 2.5 3.5", "Beans 10 2.8", "Celery 5.5 2.2"…]
		//"{type} {quantity} {price}"
		vegetables.forEach((product) => {
			let [type, quantity, price] = product.split(" ");
			quantity = Number(quantity);
			price = Number(price);
			let currentProduct = this.availableProducts.find(
				(product) => product.type === type
			);
			if (!currentProduct) {
				this.availableProducts.push({
					type,
					quantity,
					price,
				});
				this.addedProducts.push(type);
			} else {
				currentProduct.quantity += Number(quantity);
				if (currentProduct.price < price) {
					currentProduct.price = price;
				}
			}
		});
		return `Successfully added ${this.addedProducts.join(", ")}`;
	}
	buyingVegetables(selectedProducts) {
		//"{type} {quantity}"
		let totalPrice = 0.0;
		selectedProducts.forEach((product) => {
			let [type, quantity] = product.split(" ");
			quantity = Number(quantity);
			let currentProduct = this.availableProducts.find(
				(product) => product.type === type
			);
			if (!currentProduct) {
				throw new Error(
					`${type} is not available in the store, your current bill is \$${totalPrice.toFixed(
						2
					)}.`
				);
			}
			if (quantity > currentProduct.quantity) {
				throw new Error(
					`The quantity ${quantity} for the vegetable ${type} is not available in the store, your current bill is \$${totalPrice.toFixed(
						2
					)}.`
				);
			}

			totalPrice += currentProduct.price * Number(quantity);
			currentProduct.quantity -= Number(quantity);
		});
		return `Great choice! You must pay the following amount \$${totalPrice.toFixed(
			2
		)}.`;
	}
	rottingVegetable(type, quantity) {
		quantity = Number(quantity);
		let currentProduct = this.availableProducts.find(
			(product) => product.type === type
		);
		if (!currentProduct) {
			//|| currentProduct.quantity == 0) {
			throw new Error(`${type} is not available in the store.`);
		}

		currentProduct.quantity -= Number(quantity);
		if (currentProduct.quantity < 0) {
			currentProduct.quantity = 0;
			return `The entire quantity of the ${type} has been removed.`;
		}
		return `Some quantity of the ${type} has been removed.`;
	}
	revision() {
		let buff = "Available vegetables:\n";
		this.availableProducts
			.sort((a, b) => a.price - b.price)
			.forEach(
				(product) =>
					(buff += `${product.type}-${product.quantity}-$${product.price}\n`)
			);
		buff += `The owner of the store is ${this.owner}, and the location is ${this.location}.`;
		return buff;
	}
}

let vegStore = new VegetableStore("Jerrie Munro", "1463 Pette Kyosheta, Sofia");
console.log(
	vegStore.loadingVegetables([
		"Okra 2.5 3.5",
		"Beans 10 2.8",
		"Celery 5.5 2.2",
		"Celery 0.5 2.5",
	])
);
console.log(vegStore.rottingVegetable("Okra", 1));
console.log(vegStore.rottingVegetable("Okra", 2.5));
console.log(vegStore.buyingVegetables(["Beans 8", "Celery 1.5"]));
console.log(vegStore.revision());
