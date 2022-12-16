import React from 'react'

import Button from '@mui/material/Button'

import { Box, Stepper, Step, StepLabel } from '@mui/material'
import FirstStep from '../../components/SignupFirstStep'
import './style.css'

const steps = [
  'Cadastre-se ',
  'Deseja ser um professor? ',
  'Verifique seu email',
]

export default function Signup() {
  const [activeStep, setActiveStep] = React.useState(0)

  const handleNext = () => {
    if (activeStep + 1 < steps.length) {
      setActiveStep((prevActiveStep) => prevActiveStep + 1)
    }
  }

  const handleBack = () => {
    setActiveStep((prevActiveStep) => prevActiveStep - 1)
  }

  const handleSteps = (step) => {
    console.log('step ' + step)
    switch (step) {
      case 0:
        return <FirstStep handleNext={handleNext} />
      case 1:
        return 'Segundo'
      case 2:
        return 'Terceiro'
      default:
        throw new Error('Etapa desconhecida')
    }
  }

  return (
    <div id="signup">
      <Stepper activeStep={activeStep} id="stepper">
        {steps.map((label, index) => {
          const stepProps = {}
          const labelProps = {}

          return (
            <Step key={label} {...stepProps}>
              <StepLabel {...labelProps} />
            </Step>
          )
        })}
      </Stepper>

      <>
        <h1>{steps[activeStep]}</h1>
        {handleSteps(activeStep)}
        <Box sx={{ display: 'flex', flexDirection: 'row', pt: 2 }}>
          <Button
            color="inherit"
            hidden={activeStep === 0 || activeStep + 1 >= steps.length}
            onClick={handleBack}
            sx={{ mr: 1 }}
          >
            Voltar
          </Button>
          <Box sx={{ flex: '1 1 auto' }} />
          <Button onClick={handleNext} hidden={activeStep + 1 >= steps.length}>
            Próximo
          </Button>
        </Box>
      </>
    </div>
  )
}
