export class Fruit {

  public fruitId: number = -1;
  public price: number = 0;
	public name: string = "";
	public description: string = "";
	public picture: string = "";

  constructor(id: number, name: string, description: string, picture: string) {
		this.fruitId = id;
		this.name = name;
		this.description = description;
		this.picture = picture;
	}

  get Id(): number {
		return this.fruitId;
	}
	set Id(id: number) {
		this.fruitId = id;
	}

  get Price(): number {
		return this.price;
	}
	set Price(price: number) {
		this.price = price;
	}

	get Name(): string {
		return this.name;
	}
	set Name(name: string) {
		this.name = name;
	}

  get Description(): string {
		return this.description;
	}
	set Description(desc: string) {
		this.description = desc;
	}

  public get Picture(): string {
		return this.picture;
	}
	public set Picture(pic: string) {
		this.picture = pic;
	}

}
