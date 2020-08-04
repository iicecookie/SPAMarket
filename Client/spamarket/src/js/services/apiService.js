import axios from "axios";
import config from "../config/apiConfig";

class Api {
  constructor(config) {
    this.url = config.url;
  }

  async products() {
    try {
      const responce = await axios.get(`${this.url}/products`);
      console.log(responce);
    } catch (err) {
      console.log(err);
      return Promise.reject(err);
    }
  }
}

const api = new Api(config.url);

export default api;
