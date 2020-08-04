import api from "../services/apiService";

class Locations {
  constructor(api) {
    this.api = api;

    this.products = null;
  }

  async init() {
    const responce = await Promise.all([this.api.products()]);

    const [products] = responce;
    this.products = products;

    console.log(responce);
  }

  async getProductsByCategory(category) {}
}

const locations = new Locations(api);

export default locations;
