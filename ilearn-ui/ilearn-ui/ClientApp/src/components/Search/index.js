import axios from 'axios'
import React, { Component } from 'react'
import { Button, Grid } from '@mui/material'
import TextField from '@mui/material/TextField'
import './style.css'
class Search extends Component {
  constructor(props) {
    super(props)
    this.state = {
      subject: 'Matemática',
      location: 'São Paulo',
    }

    this.handleInputChange = this.handleInputChange.bind(this)
  }

  handleInputChange(event) {
    const target = event.target
    const subject = target.subject
    const location = target.location

    this.setState({
      subject,
    })
    this.setState({
      location,
    })
  }

  onSubmit(e) {
    e.preventDefault()
    console.log('chegou')
    console.log(e.target.subject.value)
    console.log(e.target.location.value)
    let url = 'https://localhost:7263/user/' + e.target.subject.value
    // 'http://api.example.com/results?q=' +
    // encodeURI(this.state.term) +
    // '&json=1'
    axios
      .get(url)
      .then((response) => {
        let data = {
          results: response.data,
        }
        console.log(data)
      })
      .catch((error) => console.log(error))
  }

  render() {
    return (
      <>
        <form id="Search" onSubmit={this.onSubmit}>
          <Grid container spacing={2}>
            <Grid item xs={12} md={5}>
              <TextField
                id="subject"
                className="search-input"
                label="O que você quer aprender?"
                aria-label="O que você quer aprender?"
                variant="outlined"
                size="small"
                fullWidth
                InputLabelProps={{ shrink: true }}
                value={this.state.subject}
                onChange={this.handleInputChange}
              />
            </Grid>
            <Grid item xs={12} md={5}>
              <TextField
                id="location"
                className="search-input"
                label="Cidade"
                aria-label="Cidade"
                variant="outlined"
                size="small"
                fullWidth
                InputLabelProps={{ shrink: true }}
                value={this.state.location}
                onChange={this.handleInputChange}
              />
            </Grid>
            <Grid item xs={12} md={2}>
              <Button
                variant="contained"
                color="secondary"
                type="submit"
                fullWidth
              >
                Buscar
              </Button>
            </Grid>
            <br />
            {/* {subject} - {location} */}
          </Grid>
        </form>
      </>
    )
  }
}

export default Search
