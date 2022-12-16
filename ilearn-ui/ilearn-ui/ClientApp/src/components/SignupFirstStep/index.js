import React, { Component } from 'react'
import { Button, TextField, FormControl } from '@mui/material'
import './style.css'

export default class FirstStep extends Component {
  constructor(props) {
    super(props)
    this.state = {
      fullName: '',
      email: '',
      phone: '',
      address: '',
      password: '',
    }

    this.handleChange = this.handleChange.bind(this)
  }

  handleNext() {
    alert('antes')
    this.props.handleNext()
    alert('depois')
  }

  handleChange(event) {
    const target = event.target
    const fullName = target.fullName
    const email = target.email
    const phone = target.phone
    const address = target.address
    const password = target.password

    this.setState({
      fullName,
    })
    this.setState({
      email,
    })
    this.setState({
      phone,
    })
    this.setState({
      address,
    })
    this.setState({
      password,
    })
  }

  render() {
    return (
      <>
        <p>Faça seu cadastro para tornar-se um aluno e/ou um professor:</p>
        <FormControl id="Signup" onSubmit={this.handleNext}>
          <TextField
            id="fullName"
            className="signup-input"
            label="Nome Completo"
            aria-label="Nome Completo"
            variant="outlined"
            sx={{ mr: 1 }}
            size="small"
            value={this.state.fullName}
            onChange={this.handleChange}
            InputLabelProps={{ shrink: true }}
            fullWidth
          />
          <br />
          <TextField
            id="email"
            className="signup-input"
            label="Email"
            aria-label="Email"
            variant="outlined"
            sx={{ mr: 1 }}
            size="small"
            value={this.state.email}
            onChange={this.handleChange}
            InputLabelProps={{ shrink: true }}
            fullWidth
          />
          <br />
          <TextField
            id="phone"
            className="signup-input"
            label="Phone"
            aria-label="Phone"
            variant="outlined"
            sx={{ mr: 1 }}
            size="small"
            value={this.state.phone}
            onChange={this.handleChange}
            InputLabelProps={{ shrink: true }}
            fullWidth
          />
          <br />
          <TextField
            id="address"
            className="signup-input"
            label="Endereçco"
            aria-label="Endereço"
            variant="outlined"
            sx={{ mr: 1 }}
            size="small"
            value={this.state.address}
            onChange={this.handleChange}
            InputLabelProps={{ shrink: true }}
            fullWidth
          />
          <br />
          <TextField
            id="password"
            className="signup-input"
            label="Senha"
            aria-label="Senha"
            variant="outlined"
            sx={{ mr: 1 }}
            size="small"
            value={this.state.password}
            onChange={this.handleChange}
            InputLabelProps={{ shrink: true }}
            fullWidth
          />
          <br />
          <TextField
            id="rptPassword"
            className="signup-input"
            label="Repetir Senha"
            aria-label="Repetir Senha"
            variant="outlined"
            sx={{ mr: 1 }}
            size="small"
            value={this.state.rptPassword}
            onChange={this.handleChange}
            InputLabelProps={{ shrink: true }}
            fullWidth
          />
          <br />
          <Button variant="contained" color="secondary" type="submit">
            Próximo
          </Button>
        </FormControl>
      </>
    )
  }
}
