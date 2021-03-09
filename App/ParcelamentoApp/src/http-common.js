import axios from "axios";

export default axios.create({
  baseURL: "http://localhost:49885/api/",
  headers: {
    'Accept': 'application/json',
    'Content-Type': 'application/x-www-form-urlencoded' 
}
});